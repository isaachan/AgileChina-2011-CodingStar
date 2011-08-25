package agilechina.codingstar.javascourceline;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.StringReader;

public class LineCounter {

    private BufferedReader sourceStream;
    private String line;
    private int lineCount;
    private boolean insideComment;

    public LineCounter(String source) {
        sourceStream = new BufferedReader(new StringReader(source));
        lineCount = 0;
        insideComment = false;
    }

    public int lineCount() throws IOException {
        line = sourceStream.readLine();
        while(line != null) {
            analysis();
            line = sourceStream.readLine();
        }
        return lineCount;
    }

    private void analysis() {
        if(enterComment(line)) {
            updateInsideCommentStatus(true);
        } else if (insideComment) {
            waitingEndOfComment();
        } else if (singleComment(line)) {
            return;
        } else  {
            countForNonEmptyLine();
        }
    }

    private void countForNonEmptyLine() {
        if (isNotEmpty()) {
            lineCount++;
        }
    }

    private void waitingEndOfComment() {
        if (exitComment(line)) {
            insideComment = false;
        }
    }

    private void updateInsideCommentStatus(boolean insideComment) {
        this.insideComment = insideComment;
    }

    private boolean exitComment(String line) {
        return line.trim().endsWith("*/");
    }

    private boolean enterComment(String line) {
        return line.trim().startsWith("/*");
    }

    private boolean      isNotEmpty() {
        return line.trim().length() > 1;
    }

    private boolean singleComment(String line) {
        return line.trim().startsWith("//");
    }
}
