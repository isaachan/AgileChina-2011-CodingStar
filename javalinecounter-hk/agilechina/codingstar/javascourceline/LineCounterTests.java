package agilechina.codingstar.javascourceline;

import org.junit.Assert;
import org.junit.Test;

import java.io.IOException;

public class LineCounterTests {

    @Test
    public void empty_file_has_no_line() throws IOException {
        LineCounter lineCounter = new LineCounter("");
        Assert.assertEquals(0, lineCounter.lineCount());
    }

    @Test
    public void count_simple_sourcefile() throws IOException {
        LineCounter lineCounter = new LineCounter("import java.util.*;");
        Assert.assertEquals(1, lineCounter.lineCount());
    }

    @Test
    public void skip_empty_line() throws IOException {
        LineCounter lineCounter = new LineCounter("import java.util.*;\n\n  \npublic class A{}");
        Assert.assertEquals(2, lineCounter.lineCount());
    }

    @Test
    public void skip_single_line_comments() throws IOException {
        LineCounter lineCounter = new LineCounter("//a comment\nimport java.util.*;");
        Assert.assertEquals(1, lineCounter.lineCount());
    }

    @Test
    public void skip_multiple_line_comments() throws IOException {
        LineCounter lineCounter = new LineCounter("/** comment 1\ncomment 2 **/\nimport java.util.*;");
        Assert.assertEquals(1, lineCounter.lineCount());
    }
}
